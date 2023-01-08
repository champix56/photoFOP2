<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">
	<xsl:output method="xml" indent="yes" version="1.0"/>
	<!--global configuration-->
	<xsl:param name="defaultUnit">mm</xsl:param>
	<!--paper configuration-->
	<xsl:param name="paperWidth" select="210"/>
	<xsl:param name="paperHeight" select="297"/>
	<!--page configuration-->
	<xsl:param name="tableCols" select="3"/>
	<xsl:param name="tableRows" select="2"/>
	
	<!--inherit configuration-->
	<xsl:variable name="imageEachPages" select="$tableCols * $tableRows"/>
	<xsl:variable name="colWidth" select="$paperWidth div $tableCols"/>
	<xsl:variable name="rowHeight" select="$paperHeight div $tableRows"/>
	<!--
		end config
	-->
	<xsl:template match="/">
		<fo:root xmlns:fo="http://www.w3.org/1999/XSL/Format">
			<fo:layout-master-set>
				<fo:simple-page-master master-name="A4" page-height="{concat($paperHeight,$defaultUnit)}" page-width="{concat($paperWidth,$defaultUnit)}">
					<fo:region-body/>
				</fo:simple-page-master>
			</fo:layout-master-set>
			<fo:page-sequence master-reference="A4">
				<fo:flow flow-name="xsl-region-body">
					<fo:block>
						<xsl:for-each select="//pages/image[(position()-1) mod $imageEachPages = 0]">
							<xsl:variable name="firstImageOnPage" select="."/>
							<xsl:call-template name="page">
								<xsl:with-param name="imageOffset" select="count(preceding-sibling::image)+1"/>
							</xsl:call-template>
						</xsl:for-each>
					</fo:block>
				</fo:flow>
			</fo:page-sequence>
		</fo:root>
	</xsl:template>
	<xsl:template name="page">
		<xsl:param name="imageOffset"/>
		<xsl:variable name="isBreakBefore"><xsl:choose>
			<xsl:when test="position()=1">auto</xsl:when>
			<xsl:otherwise>page</xsl:otherwise>
		</xsl:choose></xsl:variable>
		<fo:block break-before="{$isBreakBefore}">
		<!--<fo:table width="{concat($paperWidth,$defaultUnit)}">-->
		<fo:table width="{concat($paperWidth,$defaultUnit)}">
			<fo:table-body>
				<xsl:call-template name="rowsStructure">
					<xsl:with-param name="firstImagePosition" select="$imageOffset"/>
				</xsl:call-template>
			</fo:table-body>
		</fo:table>
		</fo:block>
	</xsl:template>
	<xsl:template name="rowsStructure">
		<xsl:param name="firstImagePosition"/>
		<xsl:param name="counter" select="0"/>
		<xsl:variable name="nextPageImagePosition" select="$tableCols * $tableRows + $firstImagePosition"/>
		<fo:table-row height="{concat($rowHeight,$defaultUnit)}">
			<xsl:for-each select="//pages/image[position() >= $firstImagePosition and position() &lt; $firstImagePosition + $tableCols ]">
				<fo:table-cell width="{concat($colWidth,$defaultUnit)}">
					<xsl:apply-templates select="."/>
				</fo:table-cell>
			</xsl:for-each>
		</fo:table-row>
		<xsl:if test="$counter &lt; $tableRows - 1 and //pages/image[$firstImagePosition + $tableCols]">
			<xsl:call-template name="rowsStructure">
				<xsl:with-param name="counter" select="$counter+1"/>
				<xsl:with-param name="firstImagePosition" select="$firstImagePosition +(($counter+1) * $tableCols)"/>
			</xsl:call-template>
		</xsl:if>
	</xsl:template>
	<xsl:template match="pages/image">
		<fo:block text-align="center">
			<fo:external-graphic src="{@path}{@href}" scaling="uniform" content-height="{concat(($colWidth*0.9),$defaultUnit)}" content-width="{concat(($rowHeight - 0.8),$defaultUnit)}"/>
			<fo:block/>
			<xsl:apply-templates select="*|text()"/>
		</fo:block>
	</xsl:template>
	<xsl:template match="fo:*">
		<xsl:copy-of select="."/>
	</xsl:template>
</xsl:stylesheet>
