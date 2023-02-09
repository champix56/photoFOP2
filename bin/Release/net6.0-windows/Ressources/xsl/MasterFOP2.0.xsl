<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format" exclude-result-prefixes="fo">
	<xsl:param name="outputType">
		<xsl:choose>
			<xsl:when test="/photos/config/output">
				<xsl:value-of select="/photos/config/output"/>
			</xsl:when>
			<xsl:otherwise>xml</xsl:otherwise>
		</xsl:choose>
	</xsl:param>
	<xsl:output method="xml" indent="yes" version="1.0"/>
	<!--global configuration-->
	<xsl:param name="defaultUnit">mm</xsl:param>
	<!--paper configuration-->
	<xsl:param name="paperWidth" select="210"/>
	<xsl:param name="paperHeight" select="297"/>
	<!--page configuration-->
	<xsl:param name="tableCols" select="/photos/config/cols"/>
	<xsl:param name="tableRows" select="/photos/config/rows"/>
	<!--inherit configuration-->
	<xsl:variable name="imageEachPages" select="$tableCols * $tableRows"/>
	<xsl:variable name="colWidth" select="$paperWidth div $tableCols"/>
	<xsl:variable name="rowHeight" select="$paperHeight div $tableRows"/>
	<!--
		end config
	-->
	<xsl:template name="getColAndRowImagesStruct">
		<xsl:param name="imagesList"/>
		<xsl:for-each select="$imagesList[(position()-1) mod $tableRows = 0]">
			<fo:table-row height="{concat($rowHeight,$defaultUnit)}">
				<xsl:for-each select=".|following-sibling::image[position() &lt; $tableCols]">
					<fo:table-cell width="{concat($colWidth,$defaultUnit)}">
						<xsl:apply-templates select="."/>
					</fo:table-cell>
				</xsl:for-each>
			</fo:table-row>
		</xsl:for-each>
	</xsl:template>
	<xsl:template match="/">
		<fo:root xmlns:fo="http://www.w3.org/1999/XSL/Format">
			<fo:layout-master-set>
				<xsl:if test="/photos/couv/* | /photos/couv4/*">
					<fo:simple-page-master master-name="PaperCouv" page-height="{concat($paperHeight,$defaultUnit)}" page-width="{concat($paperWidth,$defaultUnit)}">
						<xsl:element name="fo:region-body">
							<xsl:if test="/photos/config/backgroundAlpha/image">
								<xsl:attribute name="background-image"><xsl:value-of select="concat(/photos/config/backgroundAlpha/image/@path,photos/config/backgroundAlpha/image/@href)"/></xsl:attribute>
							</xsl:if>
						</xsl:element>
					</fo:simple-page-master>
				</xsl:if>
				<xsl:if test="/photos/config/intercal = 'True' ">
					<fo:simple-page-master master-name="PaperIntercal" page-height="{concat($paperHeight,$defaultUnit)}" page-width="{concat($paperWidth,$defaultUnit)}">
						<xsl:element name="fo:region-body">
							<xsl:choose>
								<xsl:when test="/photos/config/backgroundNoAlpha/image">
									<xsl:attribute name="background-image"><xsl:value-of select="concat(/photos/config/backgroundAlpha/image/@path,photos/config/backgroundNoAlpha/image/@href)"/></xsl:attribute>
								</xsl:when>
								<xsl:when test="/photos/config/backgroundAlpha/image">
									<xsl:attribute name="background-image"><xsl:value-of select="concat(/photos/config/backgroundAlpha/image/@path,photos/config/backgroundAlpha/image/@href)"/></xsl:attribute>
								</xsl:when>
							</xsl:choose>
						</xsl:element>
					</fo:simple-page-master>
				</xsl:if>
				<fo:simple-page-master master-name="Paper" page-height="{concat($paperHeight,$defaultUnit)}" page-width="{concat($paperWidth,$defaultUnit)}">
					<xsl:element name="fo:region-body">
						<xsl:if test="/photos/config/backgroundAlpha/image">
							<xsl:attribute name="background-image"><xsl:value-of select="concat(/photos/config/backgroundAlpha/image/@path,photos/config/backgroundAlpha/image/@href)"/></xsl:attribute>
						</xsl:if>
					</xsl:element>
				</fo:simple-page-master>
			</fo:layout-master-set>
			<xsl:apply-templates select="/photos/couv"/>
			<xsl:apply-templates select="/photos/config/intercal"/>
			<fo:page-sequence master-reference="Paper">
				<fo:flow flow-name="xsl-region-body">
					<fo:block>
						<xsl:apply-templates select="/photos/pages"/>
					</fo:block>
				</fo:flow>
			</fo:page-sequence>
			<xsl:apply-templates select="/photos/config/intercal"/>
			<xsl:apply-templates select="/photos/couv4"/>
		</fo:root>
	</xsl:template>
	<xsl:template match="/photos/couv">
		<fo:page-sequence master-reference="PaperCouv">
			<fo:flow flow-name="xsl-region-body">
				<fo:block text-align="center" margin-top="{$paperHeight*0.22}{$defaultUnit}">
					<fo:external-graphic src="{image/@path}{image/@href}" scaling="uniform" content-height="{$paperHeight*0.7}{$defaultUnit}" content-width="{$paperWidth*0.9}{$defaultUnit}"/>
					<fo:block>
						<xsl:value-of select="/photos/titre"/>
					</fo:block>
				</fo:block>
			</fo:flow>
		</fo:page-sequence>
	</xsl:template>
	<xsl:template match="/photos/couv4">
		<fo:page-sequence master-reference="PaperCouv">
			<fo:flow flow-name="xsl-region-body">
				<fo:block text-align="center" margin-top="{$paperHeight*0.17}{$defaultUnit}">
					<fo:external-graphic src="{image/@path}{image/@href}" scaling="uniform" content-height="{$paperHeight*0.4}{$defaultUnit}" content-width="{$paperWidth*0.5}{$defaultUnit}"/>
					<fo:block>
						<xsl:apply-templates select="*|text()"/>
					</fo:block>
				</fo:block>
			</fo:flow>
		</fo:page-sequence>
	</xsl:template>
	<xsl:template match="/photos/config/intercal">
		<xsl:if test=". = 'True' ">
			<fo:page-sequence master-reference="PaperIntercal">
				<fo:flow flow-name="xsl-region-body">
					<fo:block break-after="page">
						<xsl:text> </xsl:text>
					</fo:block>
					<fo:block>
						<xsl:text> </xsl:text>
					</fo:block>
				</fo:flow>
			</fo:page-sequence>
		</xsl:if>
	</xsl:template>
	<xsl:template match="pages">
		<xsl:choose>
			<xsl:when test="page">
				<xsl:for-each select="page">
					<xsl:call-template name="structured-page">
						<xsl:with-param name="imagesList" select="image"/>
					</xsl:call-template>
				</xsl:for-each>
			</xsl:when>
			<xsl:otherwise>
				<xsl:for-each select="image[(position()-1) mod ($tableCols*$tableRows)= 0]">
					<xsl:call-template name="structured-page">
						<xsl:with-param name="imagesList" select="following-sibling::image[position() &lt; $tableCols*$tableRows ]|."/>
					</xsl:call-template>
				</xsl:for-each>
			</xsl:otherwise>
		</xsl:choose>
	</xsl:template>
	<xsl:template name="structured-page">
		<xsl:param name="imagesList"/>
		<xsl:param name="isBreakBefore">
			<xsl:choose>
				<xsl:when test="position()=1">auto</xsl:when>
				<xsl:otherwise>page</xsl:otherwise>
			</xsl:choose>
		</xsl:param>
		<fo:block break-before="{$isBreakBefore}">
			<!--<fo:table width="{concat($paperWidth,$defaultUnit)}">-->
			<fo:table width="{concat($paperWidth,$defaultUnit)}">
				<fo:table-body>
					<xsl:call-template name="getColAndRowImagesStruct">
						<xsl:with-param name="imagesList" select="$imagesList"/>
					</xsl:call-template>
				</fo:table-body>
			</fo:table>
		</fo:block>
	</xsl:template>
	<xsl:template match="pages//image">
		<fo:block text-align="center" padding-top="1.5mm">
			<fo:external-graphic src="{@path}{@href}" scaling="uniform" content-height="{concat((($rowHeight - 15)*0.9),$defaultUnit)}" content-width="{concat(($colWidth - 1),$defaultUnit)}"/>
			<fo:block/>
			<xsl:apply-templates select="*|text()"/>
		</fo:block>
	</xsl:template>
	<xsl:template match="fo:*">
		<xsl:copy-of select="."/>
	</xsl:template>
</xsl:stylesheet>
